import { Injectable } from '@angular/core';
import { Users } from './users.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  constructor(private http: HttpClient) { }

  readonly apiUrl = `${environment.baseUrl}api/user`;

  getAll() {
    return this.http.get<Users[]>(this.apiUrl + '/all');
  }

  postUser(user: Users) {
    return this.http.post(this.apiUrl, user);
  }


  putUser(user: Users) {
    return this.http.put(`${this.apiUrl}/${user.userId}`, user);
  }

  deleteUser(id: number){
    return this.http.delete(`${this.apiUrl}/${id}`)
  }


}
