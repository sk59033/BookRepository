import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { BookModel } from '../models/book-model';
@Injectable({
  providedIn: 'root'
})
export class BookService {
  baseUrl:string="http://localhost:50034/";

  constructor(private httpClient: HttpClient) { }

  getAllBooks():Observable<any>{
      return this.httpClient.get(this.baseUrl+"Books/GetAllBooks");
  }
  addBook(book:BookModel):Observable<any>{
  return this.httpClient.post(this.baseUrl+"Books/AddBook",book,{responseType:'text' as 'json'});
  }
  updateBook(book:BookModel):Observable<any>{
    return this.httpClient.post(this.baseUrl+"Books/UpdateBook",book,{responseType:'text' as 'json'});
  }
  deleteBook(id:number):Observable<any>{
    return this.httpClient.post(this.baseUrl+"Books/DeleteBook"+"?id="+id,null,{responseType:'text' as 'json'});
  }
  getBookById(id:number):Observable<any>{
    return this.httpClient.get(this.baseUrl+"Books/GetBookById"+"?id="+id);
  }

  searchBook(name:any):Observable<any>{
    return this.httpClient.post(this.baseUrl+"Books/GetByBookNameOrAuthor"+"?name="+name,null)
  }
  
  getBookStatusTypes():Observable<any>{
      return this.httpClient.get(this.baseUrl+"Books/GetBookStatusTypes");
  }


}
