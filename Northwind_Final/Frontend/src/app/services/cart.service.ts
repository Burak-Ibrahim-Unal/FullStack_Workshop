import { CartItems } from './../Models/cartItems';
import { Product } from 'src/app/Models/product';
import { Injectable } from '@angular/core';
import { CartItem } from '../Models/cartItem';

@Injectable({
    providedIn: 'root'
})
export class CartService {

    constructor() { }

    addToCart(product: Product) {
        let item = CartItems.find(p => p.product.productId === product.productId);
        if (item) {
            item.quantity++;
        } else {
            let cartItem = new CartItem();
            cartItem.product = product;
            cartItem.quantity = 1;
            CartItems.push(cartItem);
        }
    }

    cartList(): CartItem[] {
        return CartItems;
    }

    removeFromCart(product: Product) {
        let item: CartItem = CartItems.find(p => p.product.productId === product.productId);
        CartItems.splice(CartItems.indexOf(item), 1);

    }

}
