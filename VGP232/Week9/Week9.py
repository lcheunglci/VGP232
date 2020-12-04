
#name = input('What is your name?')
#print(f'hello {name}')

#number = int(input('How many days to do you work?'))
#if number > 5:
#	print("That's a lot of work")
#else:
#	print("That's nice")

#for i in range(0,10):
#	count = i

#print(count)
#count = "Joe"
#print(count)

# write and read from a file
#f = open('output.txt', 'w')
#f.write("Something was suppose to be here")
#f.close()

#with open('output.txt', 'r') as f:
#	print(f.read())

#class Person:
#	def __init__(self, firstname, lastname):
#		self.firstname = firstname
#		self.lastname = lastname

#	def do_work(self):
#		print(f"{self.firstname} is doing some work")

#	def show_count():
#		print('nothing to see here')

#	def __str__(self):
#		return f"{self.firstname} {self.lastname}"

#class Employee(Person):
#	def __init__(Person, self):
#		pass


#p = Person("Lawrence", "Cheung")
##print(p)

##p.do_work()
##Person.show_count()

#mylist = ['Bob',1,'2']
#mylist[1] = 'Job'
#mylist.append('3')
#for x in mylist:
#    print(x)

#mytup = ('Bob', 1, '2')
## mytup[1] = 2 # not allowed

## set, every element has to be unique
#{'a','b','c'} 
#set([])


# dictionary, key value pairs, keys are unique
#{'a':1, 'b':2, 'c':3}

#import json
#print(json.dumps(['something', {'Joe':30}, 100]))

#import sys
#print(sys.argv)

#from optparse import OptionParser

#name = input('wait for something? ')

#parser = OptionParser()
#parser.add_option("-f", "--file", dest="filename",
#                  help="write report to FILE", metavar="FILE")
#parser.add_option("-q", "--quiet",
#                  action="store_false", dest="verbose", default=True,
#                  help="don't print status messages to stdout")

#(options, args) = parser.parse_args()

#if options.verbose == True:
#    print("Something should be showing")

#if options.filename != None:
#    print(options.filename)

# import os

# os.system('notepad')

try:
	a = 1
	b = 0
	c= a/b
except ZeroDivisionError as e:
	print(e)
	# print('cannot divide by zero')
