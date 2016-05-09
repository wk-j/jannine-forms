## Jannine Form

![](Screen/about-jannine.png)

## สร้าง RootPage

`RootPage` เป็น `MasterDetailPage` ประกอบด้วย

- `Master` ใช้แสดง Menu ของโปรแกรม
- `Detail` ใช้แสดงรายละเอียดของแต่ละ Menu

## Issue

- Error ตอนเรียกฟังก์ชัน `ExecuteLoadTweetsCommand()`

> ex	{System.Net.WebException: Error: SecureChannelFailure (The authentication or decryption has failed.) …}	System.Net.WebException

- แก้ไข คลิกขวาที่ชื่อโปรเจค `Options > iOS Build > SSL/TLS Implementation`
- เลือก `Apple TLS` แทน `Mono (TLS 1.0) | Default`
