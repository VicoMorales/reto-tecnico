import { ProductDto } from './../../models/ProductDto';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ProductPresenter } from './product.presenter';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  constructor(
    public _presenter:ProductPresenter
  ) { }

  ngOnInit(): void {
  }

}
