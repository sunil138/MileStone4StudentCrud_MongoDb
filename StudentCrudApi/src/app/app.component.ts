import { Component } from '@angular/core';
import { Student } from './models/Student';
import { StudentService } from './services/student.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'StudentCrudApi';
  //for get
  studentList:any=[]; 
  //for any data
  updatedata:any;
  //for adding  a student
  std:Student=
  {
    id:'',
    StudentName:'',
    StudentAddress:'',
    StudentAge:0,
    StudentCourse:'',
    StudentGender:'' 
  }
  //for updating a student
  currentData:Student=
  {
    id:'',
    StudentName:'',
    StudentAddress:'',
    StudentAge:0,
    StudentCourse:'',
    StudentGender:'' 
  }
  //logic for get all students
  GetStudents()
  {
    this.service.GetPosts().subscribe(response=>{
      this.studentList=response;
      console.log(response); 
    })
  }
//logic for get  student by id
  AddStudent()
  {
    this.service.AddPosts(this.std).subscribe(response=>{
      this.GetStudents();
      console.log(response); 
    })
  }
//logic for delete  student by id
  DeleteStudent(id:any)
  {
    this.service.DeletePosts(id).subscribe(response=>{
      this.GetStudents();
      console.log(response);  
    })
  }
//logic for update student
  UpdateStudent()
  {
    this.service.UpdatePosts(this.currentData).subscribe(response=>{ 
      this.GetStudents();
      console.log(response); 
    })
  }
//logic for getting student data by id 
  getdata(data:Student)
  {
    this.service.GetPostsById(data.id).subscribe(response=>{
      this.updatedata=response;
      this.currentData=this.updatedata; 
    })
  }
  constructor(private service:StudentService){}
  ngOnInit()
  {
    this.GetStudents(); 
  }
}
