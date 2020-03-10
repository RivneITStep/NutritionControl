export class ApiResponse {
  isSuccessful: boolean;
  message: string;
}

export class ApiSingleResponse extends ApiResponse {
  data: any;
}

export class ApiCollectionResponse extends ApiResponse {
  data: Array<any>;
  count: number;
}

export class ApiPaginationResponse extends ApiCollectionResponse {
  pageIndex: number;
  pageSize: number;
}