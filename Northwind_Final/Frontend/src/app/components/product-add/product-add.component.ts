import { ToastrService } from 'ngx-toastr';
import { ProductService } from './../../services/product.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms";

@Component({
    selector: 'app-product-add',
    templateUrl: './product-add.component.html',
    styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
    addProductForm: FormGroup;
    constructor(private formBuilder: FormBuilder,
        private productService: ProductService,
        private toastrService: ToastrService) { }

    ngOnInit(): void {
        this.createAddProductForm();
    }

    createAddProductForm() {
        this.addProductForm = this.formBuilder.group({
            productName: ["", Validators.required],
            categoryId: ["", Validators.required],
            unitsInStock: ["", Validators.required],
            unitPrice: ["", Validators.required],
        });
    }

    addProduct() {
        if (this.addProductForm.valid) {
            let product = Object.assign({}, this.addProductForm.value);
            this.productService.addProduct(product).subscribe(response => {
                console.log(response);
                this.toastrService.success(response.message, "Completed")
            });
        } else {
            this.toastrService.error("Product is not valid", "Error");
        }

        //console.log(product);
    }
}
