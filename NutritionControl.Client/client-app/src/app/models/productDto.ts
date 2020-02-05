export class ProductDto  { 
  id: number;
  name: string;
  caloriesValue: number;
  protein: number;
  fats: number;
  carbohydrates: number;
  categoryName: string;
}

export class GroupedProducts {
  categoryName: string;
  products : Array<ProductDto>;
}