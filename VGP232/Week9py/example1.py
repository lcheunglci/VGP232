def sum_of(left, right):
    return left + right


def sum(*numbers):
    total = 0
    for num in numbers:
        total += num
    print(total)

def add(dictionaryOfStuff):
    if isinstance(dictionaryOfStuff, dict) :
        for k, v in dictionaryOfStuff:
            print(k)
            print(v)

def config(**stuff):
    if 'studentid' in stuff:
        #print("The student id: " + str(stuff['studentid']))
        print("The student id: {0}".format(stuff['studentid']))
    if "name" in stuff:
        print("The student name: " + stuff['name'])
    if "course" in stuff:
        print("The course is: " + stuff['course'])
    for key, value in stuff.items():
        #print(key, value)
        print("{0} : {1}".format(key, value))


def main():
    name = "Bob"
    number = 100
    print("hello")
    print(name)
    print("hi " + name)
    print(sum(1, 2, 3, 4, 5, 6, 7, 8))

    print(type(name))
    print(type(number))
    print(sum_of(4, 5))
    # print(bob)
    config(studentid=100, name="Wallace", course="VGP232")
    config(student=1001, name="Joe", course="VGP130")


if __name__ == "__main__":
    main()
else:
    print(__name__)
