import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductService } from '@proxy/products';
import { ProductDto } from '@proxy/products/dtos';
// added this line
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.scss',
  providers: [
    ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }, // add this line
  ],
})
export class ProductComponent implements OnInit {
  product = { items: [], totalCount: 0 } as PagedResultDto<ProductDto>;
  form: FormGroup; // add this line
  isModalOpen = false; // add this line

  //update
  selectedProduct = {} as ProductDto; // declare selectedBook

  constructor(
    public readonly list: ListService,
    private productService: ProductService,
    private fb: FormBuilder, // inject FormBuilder
    private confirmation: ConfirmationService //delete
  ) {}

  ngOnInit() {
    const productStreamCreator = query => this.productService.getList(query);

    this.list.hookToQuery(productStreamCreator).subscribe(response => {
      this.product = response;
    });
  }

  // add new method
  createBook() {
    this.selectedProduct = {} as ProductDto; // update
    this.buildForm(); // add this line
    this.isModalOpen = true;
  }

  // Add editBook method
  editBook(id: string) {
    this.productService.get(id).subscribe(product => {
      this.selectedProduct = product;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  // Add a delete method
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this.productService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
  
  // add buildForm method
  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedProduct.name || '', Validators.required],
      code: [this.selectedProduct.code || '', Validators.required],
      purchasePrice: [this.selectedProduct.purchasePrice || '', Validators.required],
      salePrice: [this.selectedProduct.salePrice || '', Validators.required],
      // type: [null, Validators.required],
      // publishDate: [null, Validators.required],
      // price: [null, Validators.required],
    });
  }

  // add save method
  // change the save method
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedProduct.id
      ? this.productService.update(this.selectedProduct.id, this.form.value)
      : this.productService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}
