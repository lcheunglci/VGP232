import os
import glob
import sys

class Car :
    '''
    This a car class
    '''
    seats = 5

    def __init__(self, brand, model):
        self.brand = brand
        self.model = model

    def __str__(self):
        return self.brand + " " + self.model

    def __len__(self):
        return 4

    def move(self):
        print("vroom")

    def what():
        print("car")

class Tank(Car) :
    '''
    This a car class
    '''
    def __init__(self, brand, model, missle):
        Car.__init__(self, brand, model)
        self.missle = missle

    def __str__(self):
        return self.brand + " " + self.model + " "  + self.missle

    def __len__(self):
        return 4

Car.what()
print(Car.seats)

t = Tank("honda", "hrx", "homing")
print(t)
mycar = Car("Teslas", "ModelX")
print(mycar)
print(mycar.seats)
print(len(mycar))

#
# # gets all your command line arguments
# sys.argv
#
# # os.system("notepad")
# print(os.getcwd())
# os.chdir("..")
# print(os.listdir(os.getcwd()))
# print(os.environ.get("PATH", "not found"))
# #help(os.system)


