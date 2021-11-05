import { ToastrService } from 'ngx-toastr';
import { Product } from './../../Models/product';
import { CartService } from './../../services/cart.service';
import { CartItem } from './../../Models/cartItem';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-cart-summary',
    templateUrl: './cart-summary.component.html',
    styleUrls: ['./cart-summary.component.css']
})
export class CartSummaryComponent implements OnInit {
    cartItems: CartItem[] = [];

    constructor(private cardService: CartService, private toastrService: ToastrService) { }

    ngOnInit(): void {
        this.getCart();
    }

    getCart() {
        this.cartItems = this.cardService.cartList();
    }

    removeFromCart(product: Product) {
        this.cardService.removeFromCart(product);
        this.toastrService.error("Successfuly removed", product.productName)
    }


}
