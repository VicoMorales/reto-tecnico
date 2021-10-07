import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductPresenter } from '../product.presenter';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.scss']
})
export class EditProductComponent implements OnInit {
  guid:string;
  constructor(public _presenter:ProductPresenter,
    public dialogRef: MatDialogRef<EditProductComponent>,
    @Inject(MAT_DIALOG_DATA) public data) { }

  ngOnInit(): void {
    this.setProduct()
  }
  setProduct(){
    this._presenter.form.setValue({
      productName: this.data.productName,
      price: this.data.price,
      stock: this.data.stock
    })
    this.guid = this.data.id;
  }
}
