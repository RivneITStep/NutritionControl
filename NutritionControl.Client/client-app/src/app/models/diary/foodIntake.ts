import { ProductDto } from '../productDto';

export class FoodIntakeDto {
  type: string;
  dateOfIntake: Date;
  productId: number;
  foodWeight: number;
  product: ProductDto;
}