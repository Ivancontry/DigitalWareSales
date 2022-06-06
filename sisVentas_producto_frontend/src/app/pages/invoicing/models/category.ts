import { Product } from "./product";

export class Category {
    id: number | undefined;
    code: string | undefined;
    name: string | undefined;
    date: Date | undefined;
    products: Product[] = [];

}
