import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../models/Student';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  //importing httpclient
  constructor(private http:HttpClient) { }
  //getting the urllink
  GetPosts():Observable<any>
  {
    return this.http.get<any>("https://localhost:7115/api/Student");
  }
  //getting the url by id
  GetPostsById(id:any):Observable<any>
  {
    return this.http.get<any>("https://localhost:7115/api/Student"+"/"+id); 
  }
  //posting student
  AddPosts(data:any):Observable<any>
  {
    return this.http.post<any>("https://localhost:7115/api/Student",data);
  }
  //updating  a student
  UpdatePosts(data:Student):Observable<any> 
  {
    return this.http.put<any>("https://localhost:7115/api/Student"+"/"+data.id,data); 
  }
  //delete a student by id
  DeletePosts(id:any):Observable<any>
  {
    return this.http.delete<any>("https://localhost:7115/api/Student"+"/"+id);  
  }

}
