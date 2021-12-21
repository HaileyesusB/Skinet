import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Brands } from '../shared/models/brands';
import { Product } from "../shared/models/product";
import { ProductTypes } from '../shared/models/productTypes';
import { ShopParams } from '../shared/models/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static:false}) searchTerm : ElementRef | any;
  Product : Product[] | any; 
  Brands: Brands[] | any;
  ProductTypes: ProductTypes[] | any;
  shopParams = new ShopParams();
  totalCount?: number | any;
  sortOption = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'}
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
  
    this.getBrands();
    this.getProducts();
    this.getTypes();
  }

  getProducts()
  {
    this.shopService.getProduct(this.shopParams)
    .subscribe(response=> {
      this.Product = response?.data;
      this.shopParams.pageNumber = response?.pageIndex;
      this.shopParams.pageSize = response?.pageSize;
      this.totalCount = response?.count;
    }, 
    error =>{
      console.log(error);
    }
    );
  }

  getBrands()
  {
    this.shopService.getBrands().subscribe(response=> {
      this.Brands = [{id:0, name:'All'}, ...response];
    }, 
    error =>{
      console.log(error);
    }
    );
  }

  getTypes()
  {
    this.shopService.getProductTypes().subscribe(response=> {
      this.ProductTypes = [{id:0, name:'All'}, ...response];
    }, 
    error =>{
      console.log(error);
    }
    );
  }

 OnBrandSelected(brandId: number)
 {
   this.shopParams.brandId = brandId;
   this.shopParams.pageNumber = 1;
    this.getProducts();
 }

 OnTypeSelected(typeId: number)
 {
   this.shopParams.typeId = typeId;
   this.shopParams.pageNumber = 1;
   this.getProducts();
 }
 OnSortSelected(sort: any)
 {  
 this.shopParams.sort = sort;
 this.getProducts();
 }

 OnPageChanged(event : any) 
 {
   this.shopParams.pageNumber = event;
   this.getProducts();
 }

 OnSearch()
 {
   this.shopParams.search = this.searchTerm.nativeElement.value;
   this.shopParams.pageNumber = 1;
   this.getProducts();
 }

 OnReset()
 {
  this.searchTerm.nativeElement.value = '';
  this.shopParams = new ShopParams();
  this.getProducts();
 }
}
