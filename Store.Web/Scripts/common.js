
           //  Функция для изменения класса
           var changeClass = function (r,className1,className2) {
               var regex = new RegExp("(?:^|\\s+)" + className1 + "(?:\\s+|$)");
               if( regex.test(r.className) ) {
                   r.className = r.className.replace(regex,' '+className2+' ');
               }
               else{
                   r.className = r.className.replace(new RegExp("(?:^|\\s+)" + className2 + "(?:\\s+|$)"),' '+className1+' ');
               }
               return r.className;
           };   
 
//  Создание кнопки меню в JS для маленьких экранов
var menuElements = document.getElementById('menu');
menuElements.insertAdjacentHTML('afterBegin','<button type="button" id="menutoggle" class="navtoogle" aria-hidden="true"><i aria-hidden="true" class="icon-menu"> </i> Меню</button>');
 
// Переключение класса по клику - показать/скрыть меню
document.getElementById('menutoggle').onclick = function() {
    changeClass(this, 'navtoogle active', 'navtoogle');
}
