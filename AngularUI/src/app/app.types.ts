export interface PhoneBookItem {
    uuid: string,
    name: string,
    surname: string,
    company: string;
}
export interface ContactInfoDto {
    id: string,
    personID: string,
    type: InfoTypeDto,
    content: string;
}
export interface InfoTypeDto {
    address: string,
    phoneNumber: string,
    email: string,
}