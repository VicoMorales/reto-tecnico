import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Pedido } from 'src/app/models/Pedido';
@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  displayedColumns: string[] = ['idConsulta','nombreCliente', 'fecha', 'monto'];
  dataSource :Pedido[];
  user:string;
  constructor(
    private _snackBar: MatSnackBar,
    private router:Router
  ) {

   }

  ngOnInit(): void {
  }
}
