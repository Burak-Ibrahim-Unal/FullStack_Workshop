export interface Product {
    id: number;
    name: string;
    description: string;
    price: number;
    pictureUrl: string;
    type: string;
    brand: string;
    stockQuantity: number;
}

export interface ProductParams {
    orderBy: string;
    searchTerm?: string;
    types?: string[];
    brands?: string[];
    pageNumber: number;
    pageSize: number;
}