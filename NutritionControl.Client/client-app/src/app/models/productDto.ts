export class ProductDto  { 
  id: number;
  name: string;
  caloriesValue: number;
  protein: number;
  fats: number;
  carbohydrates: number;
  categoryName: string;
  isLiked: boolean;
}

export class GroupedProducts {
  categoryName: string;
  isCollapsed: boolean = true;
  products : Array<ProductDto>;
}