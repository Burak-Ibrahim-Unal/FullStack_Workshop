import { Component, OnInit } from '@angular/core';
import { ListResponseModel } from 'src/app/core/models/listResponseModel';
import { BrandService } from 'src/app/features/services/brand.service';
import { BrandListModel } from '../../models/brandListModel';

@Component({
  selector: 'app-brand-list',
  templateUrl: './brand-list.component.html',
  styleUrls: ['./brand-list.component.css']
})
export class BrandListComponent implements OnInit {

  allBrands: ListResponseModel<BrandListModel> = { items: [] };
  selectedBrand: BrandListModel;
  constructor(private brandService: BrandService) { }

  ngOnInit(): void {
    this.getBrandList()
  }

  getBrandList() {
    this.brandService.getAllBrands(0, 10).subscribe(response => {
      this.allBrands = response;
    });
  }

}
