from flask import Flask, render_template
from LoginForm import Lf
from AuthForm import AuthF

app = Flask(__name__)
app.config["SECRET_KEY"] = '18598059'

@app.route('/')
def main():
    return render_template('Base.html')


@app.route('/reg', methods=['GET', 'POST'])
def reg():
    form = Lf()
    if form.validate_on_submit():
        if form.password.data != form.passwordRepeat.data:
            return render_template("register.html", title="Регистрация", form=form, 
                                    message='Пароли не совпадают. Повторите попытку!')

        with open("G:\Workplace\Bootcamp\Programming\Lection 25 Post, Get, Forms\File.txt", "a", encoding="utf-8") as file:
            file.write(f'{form.name.data}; {form.email.data};{form.password.data}\n')
        return render_template("register.html", message ="Регистрация прошла успешно")
    return render_template("register.html", title="Регистрация", form=form)

@app.route('/login', methods=['GET', 'POST'])
def log():
    form = AuthF()
    if form.validate_on_submit():
        with open("G:\Workplace\Bootcamp\Programming\Lection 25 Post, Get, Forms\File.txt", "r", encoding="utf-8") as file:
            data = ' '.join(file.readlines()) # все строки файла соединятся через пробел (не забываем о \n)

        if form.email.data not in data:
            return render_template('login.html', form=form, message='Вы не зарегистрированы')
        else:
            for i in data.split(): # все строки разделяем по пробелам (не забываем о \n)
                if form.email.data in i: # если почта где-то есть, то
                    if i.split(';')[-1] == form.password.data: # разделяем все, что в строке по (;) после этого пароль окажется в конце, последним элементом
                        return render_template('login.html', message='Вы успешно авторизовались')



    return render_template('login.html', form=form)





@app.route('/about')
def about():
    return render_template('about.html')

if __name__ == '__main__':
    app.run()
























