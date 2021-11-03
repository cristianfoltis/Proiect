import { Injectable } from '@angular/core';
import { Users } from './users.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Device } from './devices.model';

@Injectable({
  providedIn: 'root'
})
export class DeviceService {
  constructor(private http: HttpClient) { }

  readonly apiUrl = `${environment.baseUrl}api/device`;

  getAll() {
    return this.http.get<Device[]>(this.apiUrl + '/all');
  }

  postDevice(device: Device) {
    return this.http.post(this.apiUrl, device);
  }


  putDevice(device: Device) {
    return this.http.put(`${this.apiUrl}/${device.deviceId}`, device);
  }

  deleteDevice(id: number){
    return this.http.delete(`${this.apiUrl}/${id}`)
  }


}
