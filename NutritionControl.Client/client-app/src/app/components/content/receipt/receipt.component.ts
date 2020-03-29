import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ReceiptsService } from 'src/app/services/api/receipts.service';
import { ApiSingleResponse } from 'src/app/models/apiResponse';
import { ReceiptDto } from 'src/app/models/receiptDto';

@Component({
  selector: 'app-receipt',
  templateUrl: './receipt.component.html',
  styleUrls: ['./receipt.component.css']
})
export class ReceiptComponent implements OnInit {

  id: number;
  receipt:ReceiptDto;
  constructor(private route: ActivatedRoute, private receiptsService: ReceiptsService) { 

  }

  ngOnInit() {
    this.id=this.route.snapshot.params["id"];
    this.receiptsService.getReceipt(this.id)
      .subscribe((res:ApiSingleResponse)=>{
        this.receipt=res.data;
        console.log(this.receipt);
      });
  }

}
