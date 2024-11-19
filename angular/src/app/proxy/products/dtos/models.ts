import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateUpdateProductDto {
  name: string;
  code: string;
  purchasePrice?: number;
  salePrice?: number;
}

export interface GetProductListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface ProductDto extends EntityDto<string> {
  name?: string;
  code?: string;
  purchasePrice?: number;
  salePrice?: number;
}
