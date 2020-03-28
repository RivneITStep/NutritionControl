import { ProductDto } from './productDto'

export class ProductReceiptDto {
  count: number
  measurment: string
  product: ProductDto
}

export class ReceiptDto {
  id: number
  name: string
  photoUrl: string
  description: string
  calories: number
  protein:number
  fats:number
  carbohydrates:number
  categoryName: string
  method: string
  products: Array<ProductReceiptDto>
}