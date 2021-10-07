import { CreateProductComponent } from './../scenes/product/create-product/create-product.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main/main.component';
import { MaterialModule } from '../shared/material.module';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductComponent } from '../scenes/product/product.component';

const routes: Routes = [
  {
    path: "",
    component: MainComponent
  }
];

@NgModule({
  declarations: [
    MainComponent,
    ProductComponent,
    CreateProductComponent],
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class MainModule { }
