export interface Product {
    id: number;
    name: string;
    description: string;
    price: number;
    stockQuantity: number;
    pictureUrl: string;
    type?: string;
    brand: string;
}

export interface ProductParams {
    orderBy: string;
    searchTerm?: string;
    types: string[];
    brands: string[];
    pageNumber: number;
    pageSize: number;
}