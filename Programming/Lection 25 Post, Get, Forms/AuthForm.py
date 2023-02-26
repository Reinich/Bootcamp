from flask_wtf import FlaskForm
from wtforms import StringField, PasswordField, BooleanField, SubmitField, EmailField
from wtforms.validators import DataRequired

class AuthF(FlaskForm):
    email = EmailField("email", validators = [DataRequired()])
    password = PasswordField("Пароль", validators = [DataRequired()])
    submit = SubmitField("Авторизоваться")
