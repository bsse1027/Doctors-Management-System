import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export default class AppComponent implements OnInit {

  title = 'The Dating App';

  users: any;

  constructor(private http:HttpClient)
  {

  };

  ngOnInit() {
    this.getUsers();
   
  }
 

  getUsers()
  {

    this.http.get('https://localhost:44393/api/users').subscribe(response =>{
      this.users = response;
    }, error =>{
      console.log(error);
      
    });

  }

  



}
