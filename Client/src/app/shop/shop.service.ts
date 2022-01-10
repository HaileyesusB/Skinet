import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Brands } from '../shared/models/brands';
import { Pagination } from '../shared/models/Pagination';
import { ProductTypes } from '../shared/models/productTypes';
import{map} from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
import { Product } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
 baseUrl = 'https://localhost:44365/api/';

  constructor(private https: HttpClient) { }

  getProduct(shopParams : ShopParams){

    let params = new HttpParams();

    if(shopParams.brandId!== 0){
      
     params = params.append('brandId' , shopParams.brandId.toString());
    }

    if(shopParams.search) {

      params = params.append('search' , shopParams.search);
    }

    if (shopParams.typeId !== 0)
    {
      params = params.append('typeId' , shopParams.typeId.toString());
    }
         params = params.append('sort', shopParams.sort);
         params = params.append('pageIndex', shopParams.pageNumber.toString());
         params = params.append('pageIndex', shopParams.pageSize.toString());
    
    return this.https.get<Pagination>(this.baseUrl + 'Product', {
      observe: 'response', params 
     })
    .pipe(
      map(response=>{
      return response.body;
    })
    );
  }

  getBrands()
  {
    return this.https.get<Brands[]>(this.baseUrl + 'Product/brands');
  }

  getProductTypes(){
    return this.https.get<ProductTypes[]>(this.baseUrl + 'Product/types');
  }
  
  getProductsById(id: number)
  {
    return this.https.get<Product>(this.baseUrl + 'Product/'  + id)
  }

  }
