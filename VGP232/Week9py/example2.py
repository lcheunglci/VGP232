#import example1
#example1.main()

from example1 import main
#main()

monsters = [ 1, 'rathalos', 1.02, 'rathian', 'zinorge', 'brachdios', 'nargacuga']
monsterSet = {'rathalos', 'rathian', 'zinorge', 'brachdios', 'nargacuga', 'rathalos'}
monsterSet2 = {'rathalos', 'brachdios', 'nargacuga'}

print(monsterSet & monsterSet2)

print(monsterSet - monsterSet2)


#
# monsterDict = {'rathalos': 'red', 'rathian': 'green', 'zinorge':'yellow', 'brachdios':'purple', 'nargacuga': 'black'}
#
# for mon in monsters :
#     print(mon)
#
# for mon in monsterDict :
#     print(mon)
#
# #for mon, color in monsterDict.items() :
# #    print("[{}] : >>> {} <<< ".format(mon, color))
#
# print(monsterDict)
#
# del(monsterDict['rathalos'])
#
# monsterDict.clear() # this will empty the dict but the dictionary is still there
#
# del(monsterDict) # delete the variable and set it to None
#
# for mon, color in monsterDict.items() :
#     print("[{}] : >>> {} <<< ".format(mon, color))
