import { Component, OnInit } from '@angular/core';
import { BrandService } from '../../services/brand.service';
import { ListResponseModel } from '../../../../core/models/listResponseModel';
import { BrandListModel } from '../../models/brandListModel';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css']
})
export class BrandComponent implements OnInit {
  brands: ListResponseModel<BrandListModel> = { items: [] };
  selecteddBrand: BrandListModel;


  constructor(private brandService: BrandService) { }

  ngOnInit(): void {
    this.getBrands();
  }

  getBrands() {
    this.brandService.getBrands(0, 100).subscribe(data => {
      this.brands = data;
    });
  }


}
