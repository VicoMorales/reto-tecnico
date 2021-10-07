import { EditProductComponent } from './edit-product/edit-product.component';
import { ProductHttp } from './../../http/product.http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';
import { ProductDto } from 'src/app/models/ProductDto';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';



@Injectable({
  providedIn: 'root'
})
export class ProductPresenter {
  displayedColumns: string[] = ['id', 'productName', 'price', 'stock', 'registrationDate', 'options'];
  dataSource: ProductDto[];

  form: FormGroup;



  constructor(
    private _snackBar: MatSnackBar,
    private _productHttp: ProductHttp,
    public dialog: MatDialog) {
    this.getProducts();
    this.form = new FormGroup({
      productName: new FormControl('', Validators.required),
      price: new FormControl(0, Validators.required),
      stock: new FormControl(0, [Validators.required, Validators.min(1)])
    });
  }
  addProduct() {
    if (!this.form.invalid) {
      this._productHttp.addProduct(this.form.value).subscribe(
        result => {
          if (result) {
            this._snackBar.open('Se guardó correctamente', 'Success', {
              duration: 3000
            })
            this.getProducts();
          }
        }
      );
    }
  }
  getProducts() {
    this._productHttp.getProducts().subscribe(
      result => {
        this.dataSource = result;
      }
    )
  }
  openEdit(el) {
    const dialogRef = this.dialog.open(EditProductComponent, {
      width: '500px',
      data: el
    });
  }

  editProduct(guid) {
    if (!this.form.invalid) {
      this._productHttp.editProduct({ id: guid, ...this.form.value }).subscribe(
        result => {
          if (result) {
            this._snackBar.open('Se guardó correctamente', 'Success', {
              duration: 3000
            })
            this.form.reset();
            this.getProducts();
          }
        }
      );
    }
  }
  deleteProduct(el) {
    this._productHttp.deleteProduct(el.id).subscribe(
      result => {
        if (result) {
          this._snackBar.open('Se borró correctamente', 'Success', {
            duration: 3000
          })
          this.getProducts();
        }
      }
    );
  }
}
