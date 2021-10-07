import { ProductPresenter } from './../product.presenter';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.scss']
})
export class CreateProductComponent implements OnInit {

  constructor(public _presenter:ProductPresenter) { }

  ngOnInit(): void {
  }

}
