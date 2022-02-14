import { Component, OnInit } from '@angular/core';

import { mutualfundsholdingsService } from '../services/mutualfundsholdings.service';


@Component({
  selector: 'app-counter-component',
  templateUrl: './MutualFundHoldings.component.html'
})
export class MutualFundHoldingComponent implements OnInit {

  constructor(private _mutualfundsholdingsService: mutualfundsholdingsService) {
    //  this.getEmployees();
  }

  restItems: any;

  ngOnInit() {
   this.getRestItems();
  }

  // Read all REST Items
  getRestItems(): void {
    this._mutualfundsholdingsService.getAll()
      .subscribe(
        restItems => {
          this.restItems = restItems;
          console.log(this.restItems);
        }
      )
  }

}
