import { Component, OnInit } from '@angular/core';
import { ReceiptsService } from 'src/app/services/api/receipts.service';
import { ApiCollectionResponse } from 'src/app/models/apiResponse';
import { ReceiptDto } from 'src/app/models/receiptDto';

@Component({
  selector: 'app-receipts',
  templateUrl: './receipts.component.html',
  styleUrls: ['./receipts.component.css']
})
export class ReceiptsComponent implements OnInit {

  receipts: Array<ReceiptDto>;

  constructor(private receiptsService: ReceiptsService) { }

  ngOnInit() {
    this.receiptsService.getReceipts()
    .subscribe((res: ApiCollectionResponse) => {
      if(res.isSuccessful)
        this.receipts = res.data;
    });
  }
}