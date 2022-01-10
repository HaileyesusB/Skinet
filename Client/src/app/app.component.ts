import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Product } from './shared/models/product';
//import { Product } from './shared/models/product';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  product: Product[];
  

constructor(){

}

ngOnInit(): void{
/*

  this.http.get('https://localhost:44365/api/product?pageSize=50')
  .subscribe((response: any)=>{
  this.product = response.data;
}, 
error =>{
  console.error(error);
});
*/
}
}
