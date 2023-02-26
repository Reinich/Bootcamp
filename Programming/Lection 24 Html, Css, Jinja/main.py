from flask import Flask, render_template

app = Flask(__name__)


@app.route('/')
def main():
    with open("G:\Workplace\Bootcamp\Programming\Lection 24 Html, Css, Jinja\File.txt", 'r', encoding='utf-8') as file:
        resultData = list()
        for line in file.readlines():
            resultData.append(tuple(line.split('\n')[0].split(';')))
    return render_template('Base.html', data = resultData)

'''
a - режим добавления
w - режим на запись(очищает файл)
r - режим чтения
'''

@app.route('/about')
def about():
    return render_template('about.html')

if __name__ == '__main__':
    app.run()
























