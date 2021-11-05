import { Product } from 'src/app/Models/product';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterPipe'
})
export class FilterPipePipe implements PipeTransform {

  transform(value: Product[], filterProduct: string): Product[] {
    filterProduct = filterProduct ? filterProduct.toLocaleLowerCase() : ""
    return filterProduct
    ? value.filter((p: Product) => p.productName.toLocaleLowerCase().indexOf(filterProduct) !== -1)
    : value;
  }

}
