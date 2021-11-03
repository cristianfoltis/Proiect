import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Device } from '../shared/devices.model';
import { DeviceService } from '../shared/devices.service';
import { Users } from '../shared/users.model';
import { UsersService } from '../shared/users.service';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styles: [
  ]
})
export class DevicesComponent {
  device = new Device();
  devices: Device[] = [];
  isEdit = false;
  users: Users[] = [];

  ngOnInit(): void {
    this.get();
    this.getUsers();

  }
  constructor(public userService: UsersService,
    public deviceService: DeviceService,
    private toastr: ToastrService) {

  }

  get() {
    this.deviceService.getAll().subscribe(
      res => {
        this.devices = res;
      },
      err => {
        this.toastr.error('Devices couldnt be load');
      }
    )
  }

  getUsers() {
    this.userService.getAll().subscribe(
      res => {
        this.users = res;
      },
      err => {
        this.toastr.error('Devices couldnt be load');
      }
    )
  }

  
  onSubmit() {
    var us = this.users.find(x=>x.userId==this.device.userId);
    
    if (us != undefined)
    this.device.user = us;
    if (this.isEdit)
      this.updateDevice();
    else
      this.addDevice();
  }

  addDevice() {
    this.deviceService.postDevice(this.device).subscribe(
      res => {
        this.resetForm();
        this.toastr.success('Submitted successfully', 'Devices register');
        this.get();
      },
      err => { console.log(err); }
    );
  }

  updateDevice() {
    this.deviceService.putDevice(this.device).subscribe(
      res => {
        this.resetForm();
        this.get();
        this.toastr.success('Submitted successfully', 'Users register')
      },
      err => { console.log(err); }
    );
  }

  resetForm() {
    this.device = new Device();
    this.isEdit = false;
  }

  onSelect(device: Device) {
    this.device = device;
    this.isEdit = true;
  }

  remove(event: any, device: Device) {
    event.stopPropagation();
    var r = confirm("Do you want to delete the device?");
    if (r == false) {
      return;
    }

    this.deviceService.deleteDevice(device.deviceId).subscribe(
      res => {
        this.devices = this.devices.filter(obj => obj !== device);
        this.toastr.success('Deleted successfully')
      },
      err => {
        this.toastr.error('Device couldnt be deleted');
      })
  }
}