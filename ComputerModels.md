# Models

## 1. PersonalComputer
- Id 
- Model
- Price
- Motherboard ( model )
- Procesor ( model )
- VideoCard ( model )
- Memory ( model )
- HardDrives ( model ) ( can have more than one HardDrive )
- Cooling ( model ) ( this is not set )

## 2. Motherboard
- Id
- Model
- Price
- Manufacturer
- Quantity ( this is not set )
- Computers

## 3. Procesor
- Id
- Model
- Price
- FrequencyInMhz
- Manufacturer
- Quantity ( this is not set )
- Computers

## 4. VideoCard
- Id
- Model
- Price
- Manufacturer 
- Quantity ( this is not set )
- Computers

## 5. Memory
- Id
- CapacityInGb
- Price
- Manufacturer
- Quantity ( this is not set )
- Computers

## 6. HardDrive
- Id
- Model
- Price
- CapacityInGb
- Manufacturer
- Quantity ( this is not set )
- Computers

## 7. Cooling (this is not set)
- Id
- Price
- Quantity
- Computers

## 8. ComputerShop (can delete if it is unnecessary)
- Id
- Name
- Computers 