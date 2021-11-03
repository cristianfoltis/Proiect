import { Users } from "./users.model";

export class Device {
    userId: number=0;
    deviceId: number = 0;
    deviceName: string = '';
    manufacturer: string = '';
    deviceType: string = '';
    deviceOS: string = '';
    deviceProcessor: string = '';
    deviceRAM: string = '';
    user: Users = new Users();
}
