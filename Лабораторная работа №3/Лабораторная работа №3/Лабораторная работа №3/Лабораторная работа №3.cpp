#include <iostream>
#include <ctime>

using namespace std;

class Base {

public:

	virtual void classname() = 0;
	virtual ~Base() {
		cout << "~Base()\n\n";
	}
};

class Obj_1 : public Base {

public:

	Obj_1() {
		cout << "Obj_1::Obj_1()\n";
	}

	~Obj_1() {
		cout << "Obj_1::~Obj_1()\n";
	}

	void classname() override {
		cout << "Obj_1::classname\n";
	}

	virtual void mew()
	{
		cout << "Obj_1::mew()\n";
	}
};

class Obj_2 : public Obj_1 {

public:

	Obj_2() {
		cout << "Obj_2::Obj_2()\n";
	}

	~Obj_2() {
		cout << "Obj_2::~Obj_2\n";
	}

	void classname() override {
		cout << "Obj_2::classname\n";
	}

	void mew() override
	{
		cout << "Obj_2::mew2()\n";
	}
};

class Obj_3 : public Base {

public:

	Obj_3() {
		cout << "Obj_3::Obj_3()\n";
	}

	~Obj_3() {
		cout << "Obj_3::~Obj_3()\n";
	}

	void classname() override {
		cout << "Obj_3::classname\n";
	}

	virtual void bark()
	{
		cout << "Obj_3::bark()\n";
	}
};

class Obj_4 : public Obj_3 {

public:

	Obj_4() {
		cout << "Obj_4::Obj_4()\n";
	}

	~Obj_4() {
		cout << "Obj_4::~Obj_4()\n";
	}

	void classname() override {
		cout << "Obj_4::classname\n";
	}

	void bark() override
	{
		cout << "Obj_4::bark2()\n";
	}
};

//-----------------------

class MyStorage {

private:

	Base** data{};
	int curr = 0;	//текущий элемент массива
	int size = 10;	//размер массива
	int count = 0;	//количество заполненных элементов массива

	void resize() {				//Увеличение размера массива на 1 путем создания нового и копирования из старого

		size++;

		Base** tmp = new Base * [size]();

		for (int i = 0; i < size - 1; i++)
			tmp[i] = data[i];

		data = tmp;
	}

public:

	MyStorage() {				
		data = new Base * [size]();
		this->first();
	}

	void add(Base* obj) {		//Добавление нового объекта

		if (this->isEOL())		//В случае, если достигнут конец массива происходит его увеличение
		{
			if (count < curr) {					//Производится дополнительная проверка на случай, если количество занятых элементов меньше текущего счетчика
				for (int i = 0; i < size; i++)
					if (data[i] == NULL) {
						data[i] = obj;
						count++;
						return;
					}
			}

			this->resize();
		}

		data[curr] = obj;
		curr++;
		count++;
	}

	void del(Base* obj) {		//Удаление
		delete obj;
		data[curr] = NULL;
		count--;
	}

	Base* getObject() {			//Вызов текущего объекта контейнера
		return data[curr];
	}

	void first() {				//Смещение счетчика текущего объекта на первый элемент
		curr = 0;
	}

	void next() {				//Смещение счетчика текущего объекта на один элемент
		curr++;
	}

	void current() {			//Обращение к счетчику текущего объекта
		printf("%d", curr);
	}

	void counter() {			//Обращение к количеству элементов в контейнере
		printf("%d", count);
	}

	bool isEOL() {				//Проверка конца массива
		return curr > size - 1;
	}
};


void addition(MyStorage& storage) {		//Рандомное добавление объектов в контейнер

	if (rand() % 4 == 0)
		storage.add(new Obj_1);
	else if (rand() % 4 == 1)
		storage.add(new Obj_2);
	else if (rand() % 4 == 2)
		storage.add(new Obj_3);
	else
		storage.add(new Obj_4);

	cout << endl;
}

void cycle(MyStorage& storage, int count) {		//Выполнение рандомных методов и просчитывание времени, затраченное на их выполнение

	storage.first();

	int t1 = clock();

	for (int i = 0; i < count; i++)
		if (!storage.isEOL())					
		{	
			if (storage.getObject() != NULL)
			{
				if (rand() % 4 == 0) {
					storage.del(storage.getObject());
					storage.next();
				}
				else if (rand() % 4 == 1) {
					storage.getObject()->classname();
					storage.next();
				}
				else if (rand() % 4 == 2)
				{
					if (dynamic_cast<Obj_1*>(storage.getObject()) != NULL)
						dynamic_cast<Obj_1*>(storage.getObject())->mew();
					else if (dynamic_cast<Obj_3*>(storage.getObject()) != NULL)
						dynamic_cast<Obj_3*>(storage.getObject())->bark();

					storage.next();
				}
				else addition(storage);
			}
			else addition(storage);
		}
		else
			storage.first();

	int t2 = clock();

	int t = t2 - t1;
	cout << "\nTIME = " << t / 1000.0;
}

int main()
{
	srand(time(0));

	MyStorage storage;

	for (int i = 0; i < 10; i++)
		addition(storage);

	cout << "THE FIRST 10 ELEMENTS: " << endl << endl;

	for (storage.first(); !storage.isEOL(); storage.next())
		storage.getObject()->classname();

	/*cout << "\nCYCLE 100" << endl << endl;
	cycle(storage, 100);
	cout << endl;
	storage.current();*/

	/*cout << "\nCYCLE 1000" << endl << endl;
	cycle(storage, 1000);
	cout << endl;
	storage.counter();*/

	cout << "\nCYCLE 10000" << endl << endl;
	cycle(storage, 10000);

	return 0;
}