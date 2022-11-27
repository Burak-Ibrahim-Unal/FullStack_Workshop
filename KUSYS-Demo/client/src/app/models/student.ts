export interface Student {
    id: number;
    firstname: string;
    lastname: string;
    birthdate: string;
}

export interface StudentParams {
    orderBy: string;
    searchTerm?: string;
    courses: string[];
    pageNumber: number;
    pageSize: number;
}