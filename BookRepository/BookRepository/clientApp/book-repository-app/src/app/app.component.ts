import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BookModel } from './models/book-model';
import { BookStatusModel } from './models/book-status-model';
import { BookService } from './services/book.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'book-repository-app';
  allBooks:BookModel[];
  bookStatusTypes:BookStatusModel[];
  selectedStatus:BookStatusModel;
  book:BookModel=new BookModel();
  loading: boolean = true;
  bookSearch:string;
  flag:string="add";
  constructor(private bookService:BookService, 
              private toastr:ToastrService){

  }

  ngOnInit(){
    this.flag='add';
    this.getBookStatusTypes();
    this.getAllBooks();
    this.loading = false;
  }

  getAllBooks(){
    this.bookService.getAllBooks().subscribe((res:any)=>{
        if(res){
          this.allBooks=res;
        }
    });
  }
  getBookStatusTypes(){
      this.bookService.getBookStatusTypes().subscribe((res:any)=>{
        if(res){
        this.bookStatusTypes=res;
        }
      })
  }

  AddBook(book:BookModel,selectedStatus:BookStatusModel){
    if(Object.keys(book).length>0 && selectedStatus){
      book.Status=selectedStatus.id;
      if(this.flag=='add'){
      this.bookService.addBook(book).subscribe((res:any)=>{
        if(res){
          this.getAllBooks();
          this.toastr.success(res);
          this.book=new BookModel();

        }
        else{
          this.toastr.error("Something went wrong");
        }
    });
    }else if(this.flag=='update'){
       this.bookService.updateBook(book).subscribe((res:any)=>{
        if(res){
          this.toastr.success(res);
          this.getAllBooks();
          this.book=new BookModel();
          this.flag='add';
        }
        else{
          this.toastr.error("Book detail is not updated");
        }
      });
    }
  }
  else{
    this.toastr.error("All fields are mandatory to fill");
  }
  }
  

  searchBook(search:string){
    if(search){
      this.bookService.searchBook(search).subscribe((res:any)=>{
        if(res){
          this.allBooks=res;
        }
        else{
          this.toastr.info("Record not found");
        }
      })
    }
  }

  deleteBook(id:any){
    if(id){
      this.bookService.deleteBook(id).subscribe((res:any)=>{
        if(res){
          this.toastr.info(res);
          this.getAllBooks();
        }
        else{
          this.toastr.error("Book is not deleted");
        }
      })
  
    }
  }

  editBook(book:any){
    if(Object.keys(book).length>0){
        this.book.Id=book.id;
        this.book.BookName=book.bookName;
        this.book.AuthorName=book.authorName;

        this.bookStatusTypes.forEach(element => {
          if(element.id==book.status){
            this.selectedStatus=new BookStatusModel();
            this.selectedStatus.id=element.id;
            this.selectedStatus.status=element.status;
          }
        });
        this.flag='update';
    }
  }

  Reset(){
    this.book=new BookModel();
    this.selectedStatus=new BookStatusModel();
    this.flag='add';
  }

  clear(table: any) {
    table.clear();
}
clearSearch(){
  this.getAllBooks();
  this.bookSearch='';
}
target(event: KeyboardEvent): HTMLInputElement {
  if (!(event.target instanceof HTMLInputElement)) {
    throw new Error("wrong target");
  }
  return event.target;
}
}
