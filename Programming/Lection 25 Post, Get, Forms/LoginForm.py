from flask_wtf import FlaskForm
from wtforms import StringField, PasswordField, BooleanField, SubmitField, EmailField
from wtforms.validators import DataRequired

class Lf(FlaskForm):
    name = StringField("Имя", validators = [DataRequired()])
    email = EmailField("email", validators = [DataRequired()])
    password = PasswordField("Пароль", validators = [DataRequired()])
    passwordRepeat = PasswordField("Повтор пароля", validators = [DataRequired()])
    remember = BooleanField("Запомнить?")
    submit = SubmitField("Зарегистрироваться")