import { Product } from "../../app/models/product";

interface Props{
    products:Product[];
    addProduct: () => void;
}

export default function ProductList({products,addProduct} : Props){
    return(
        <div>
            <h1>Ecom</h1>
            <ul>
            {products.map((item, index) => (
                <li key={index}>
                {" "}
                {item.name} ---  {item.description} ---{item.price}TL ---  {item.stockQuantity} Adet
                </li>
            ))}
            </ul>
            <button onClick={addProduct}>Kaydet</button>
        </div>
    )
}