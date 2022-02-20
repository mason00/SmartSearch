import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';

@Injectable({
  providedIn: 'root'
})
export class SmartsearchService {

  constructor(private http: HttpClient) { }

  searchProduct(text: string){
    console.log(`smartSearchUrl ${environment.smartSearchUrl}`);

    const searchUrl = `${environment.smartSearchUrl}/api/ProductSearch/${text}`;
    this.http.get(searchUrl).subscribe(data => console.log(`data: ${data}`));
  }
}
