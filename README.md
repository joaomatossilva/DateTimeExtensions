JSFiddle'da düzenle
JavaScript
HTML
PostCSS (Aşama 3+)
Sonuç
:kök {
  -- renk -1: rgb( 62 , 80 , 60 );
  -- renk -2: rgb( 127 , 136 , 106 );
  -- renk -3: rgb( 243 , 236 , 219 );
  -- renk -4: rgb( 255 , 111 , 61 );
}

gövde {
   arka plan : lineer-gradient( 90deg , var(--color- 1 ) %0 , var(--color- 1 ) %25 , var(--color- 2 ) %25 , var(--color- 2 ) %50 , var(--color- 3 ) %50 , var(--color- 3 ) %75 , var(--color- 4 ) %75 , var(--color- 4 ) %100 );
} gövde {
   arka plan : #20262e ;
   dolgu : 16px ;
   yazı tipi ailesi : Helvetica;
}

gövde ::-webkit-kaydırma çubuğu {
  genişlik: 5px ;
}

gövde ::-webkit-kaydırma çubuğu-izi {
  arka plan: şeffaf;
}

gövde ::-webkit-kaydırma çubuğu-başparmak {
  konum: mutlak;
  arka plan : #374353ff ;
   kenarlık yarıçapı : 5px ;
}

.inputs-wrapper {
   ekran : esnek;
   esnek-yön : sütun;
  boşluk: 12px ;
}

.alan-grubu {
   görüntüleme : esnek;
   esnek-yön : sütun;
  boşluk: 6px ;
}

.label {
   yazı tipi boyutu : 12px ;
   satır yüksekliği : 14px ;
   renk : beyaz;
}

.input {
   genişlik : %100 ;
   dolgu : 4px ;

  & :focus {
     anahat : hiçbiri;
  }
}

.field {
   görüntüleme : flex;
   flex-direction : sütun;
  boşluk: 4px ;
}

.divider {
   genişlik : %100 ;
   yükseklik : 1px ;
   arka plan : gri;
}

.section {
   görüntüleme : flex;
   flex-yön : sütun;
  boşluk: 4px ;
}

.table-wrapper {
   taşma-x : otomatik;
}

.tablo-sarmalayıcı ::-webkit-kaydırma çubuğu {
  genişlik: 5px ;
}

.tablo-sarmalayıcı ::-webkit-kaydırma çubuğu-izi {
  arka plan: şeffaf;
}

.tablo-sarmalayıcı ::-webkit-kaydırma çubuğu-küçük resim {
  konum: mutlak;
  arka plan : #374353ff ;
   kenarlık yarıçapı : 5px ;
}

tablo {
   genişlik : %100 ;
   kenarlık-daraltma : daralt;
}

tablo  th {
   dolgu : 8px ;
   kenarlık : 1px düz gri;
   renk : beyaz;
   yazı tipi boyutu : 12px ;
   boşluk : nowrap;
   yazı tipi ağırlığı : 600 ;
}

tablo  td {
   dolgu : 8px ;
   kenarlık : 1px düz gri;
   renk : beyaz;
   yazı tipi boyutu : 12px ;
   metin hizalaması : orta;
}

tablo  başlığı  td {
   yazı tipi ağırlığı : 600 ;
}

.text {
   renk : beyaz;
   yazı tipi boyutu : 14px ;
   yazı tipi stili : italik;
}

.altyazı {
   renk : beyaz;
   yazı tipi boyutu : 14px ;
   yazı tipi ağırlığı : 600 ;
}

.math {
   dolgu : 4px ;
   renk : beyaz;
   yazı tipi boyutu : 12px ;
}

*Replace this paragraph with a description of what this PR is changing or adding, and why. Consider including before/after screenshots.*

*List which issues are fixed by this PR.*

*Please add a note to `packages/devtools_app/release_notes/NEXT_RELEASE_NOTES.md` if your change requires release notes. Otherwise, add the 'release-notes-not-required' label to the PR.*

## Pre-launch Checklist

- [x] I read the [Contributor Guide] and followed the process outlined there for submitting PRs.
- [x] I read the [Tree Hygiene] wiki page, which explains my responsibilities.
- [x] I read the [Flutter Style Guide] _recently_, and have followed its advice.
- [x] I signed the [CLA].
- [x] I listed at least one issue that this PR fixes in the description above.
- [x] I updated/added relevant documentation (doc comments with `///`).
- [x] I added new tests to check the change I am making, or there is a reason for not adding tests.


![build.yaml badge]

If you need help, consider asking for help on [Discord].

<!-- Links -->
[Contributor Guide]: https://github.com/flutter/devtools/blob/master/CONTRIBUTING.md
[Tree Hygiene]: https://github.com/flutter/flutter/blob/master/docs/contributing/Tree-hygiene.md
[Flutter Style Guide]: https://github.com/flutter/flutter/blob/master/docs/contributing/Style-guide-for-Flutter-repo.md
[CLA]: https://cla.developers.google.com/
[Discord]: https://github.com/flutter/flutter/blob/master/docs/contributing/Chat.md
[build.yaml badge]: https://github.com/flutter/devtools/actions/workflows/build.yaml/badge.svg

```JSFiddle'da düzenle
JavaScript
HTML
PostCSS (Aşama 3+)
Sonuç
:kök {
  -- renk -1: rgb( 62 , 80 , 60 );
  -- renk -2: rgb( 127 , 136 , 106 );
  -- renk -3: rgb( 243 , 236 , 219 );
  -- renk -4: rgb( 255 , 111 , 61 );
}

gövde {
   arka plan : lineer-gradient( 90deg , var(--color- 1 ) %0 , var(--color- 1 ) %25 , var(--color- 2 ) %25 , var(--color- 2 ) %50 , var(--color- 3 ) %50 , var(--color- 3 ) %75 , var(--color- 4 ) %75 , var(--color- 4 ) %100 );
} gövde {
   arka plan : #20262e ;
   dolgu : 16px ;
   yazı tipi ailesi : Helvetica;
}

gövde ::-webkit-kaydırma çubuğu {
  genişlik: 5px ;
}

gövde ::-webkit-kaydırma çubuğu-izi {
  arka plan: şeffaf;
}

gövde ::-webkit-kaydırma çubuğu-başparmak {
  konum: mutlak;
  arka plan : #374353ff ;
   kenarlık yarıçapı : 5px ;
}

.inputs-wrapper {
   ekran : esnek;
   esnek-yön : sütun;
  boşluk: 12px ;
}

.alan-grubu {
   görüntüleme : esnek;
   esnek-yön : sütun;
  boşluk: 6px ;
}

.label {
   yazı tipi boyutu : 12px ;
   satır yüksekliği : 14px ;
   renk : beyaz;
}

.input {
   genişlik : %100 ;
   dolgu : 4px ;

  & :focus {
     anahat : hiçbiri;
  }
}

.field {
   görüntüleme : flex;
   flex-direction : sütun;
  boşluk: 4px ;
}

.divider {
   genişlik : %100 ;
   yükseklik : 1px ;
   arka plan : gri;
}

.section {
   görüntüleme : flex;
   flex-yön : sütun;
  boşluk: 4px ;
}

.table-wrapper {
   taşma-x : otomatik;
}

.tablo-sarmalayıcı ::-webkit-kaydırma çubuğu {
  genişlik: 5px ;
}

.tablo-sarmalayıcı ::-webkit-kaydırma çubuğu-izi {
  arka plan: şeffaf;
}

.tablo-sarmalayıcı ::-webkit-kaydırma çubuğu-küçük resim {
  konum: mutlak;
  arka plan : #374353ff ;
   kenarlık yarıçapı : 5px ;
}

tablo {
   genişlik : %100 ;
   kenarlık-daraltma : daralt;
}

tablo  th {
   dolgu : 8px ;
   kenarlık : 1px düz gri;
   renk : beyaz;
   yazı tipi boyutu : 12px ;
   boşluk : nowrap;
   yazı tipi ağırlığı : 600 ;
}

tablo  td {
   dolgu : 8px ;
   kenarlık : 1px düz gri;
   renk : beyaz;
   yazı tipi boyutu : 12px ;
   metin hizalaması : orta;
}

tablo  başlığı  td {
   yazı tipi ağırlığı : 600 ;
}

.text {
   renk : beyaz;
   yazı tipi boyutu : 14px ;
   yazı tipi stili : italik;
}

.altyazı {
   renk : beyaz;
   yazı tipi boyutu : 14px ;
   yazı tipi ağırlığı : 600 ;
}

.math {
   dolgu : 4px ;
   renk : beyaz;
   yazı tipi boyutu : 12px ;
}
```
# *Replace this paragraph with a description of what this PR is changing or adding, and why. Consider including before/after screenshots.*

*List which issues are fixed by this PR.*

*Please add a note to `packages/devtools_app/release_notes/NEXT_RELEASE_NOTES.md` if your change requires release notes. Otherwise, add the 'release-notes-not-required' label to the PR.*

## Pre-launch Checklist

- [x] I read the [Contributor Guide] and followed the process outlined there for submitting PRs.
- [x] I read the [Tree Hygiene] wiki page, which explains my responsibilities.
- [x] I read the [Flutter Style Guide] _recently_, and have followed its advice.
- [x] I signed the [CLA].
- [x] I listed at least one issue that this PR fixes in the description above.
- [x] I updated/added relevant documentation (doc comments with `///`).
- [x] I added new tests to check the change I am making, or there is a reason for not adding tests.


![build.yaml badge]

If you need help, consider asking for help on [Discord].

<!-- Links -->
[Contributor Guide]: https://github.com/flutter/devtools/blob/master/CONTRIBUTING.md
[Tree Hygiene]: https://github.com/flutter/flutter/blob/master/docs/contributing/Tree-hygiene.md
[Flutter Style Guide]: https://github.com/flutter/flutter/blob/master/docs/contributing/Style-guide-for-Flutter-repo.md
[CLA]: https://cla.developers.google.com/
[Discord]: https://github.com/flutter/flutter/blob/master/docs/contributing/Chat.md
[build.yaml badge]: https://github.com/flutter/devtools/actions/workflows/build.yaml/badge.svg
{% code title="index.js" overflow="wrap" lineNumbers="true" %}

```javascript
‌import * as React from 'react';
import ReactDOM from 'react-dom';
import App from './App';

ReactDOM.render(<App />, window.document.getElementById('root'));
```

{% endcode %}
JSFiddle'da düzenle
JavaScript
HTML
PostCSS (Aşama 3+)
Sonuç
:kök {
  -- renk -1: rgb( 62 , 80 , 60 );
  -- renk -2: rgb( 127 , 136 , 106 );
  -- renk -3: rgb( 243 , 236 , 219 );
  -- renk -4: rgb( 255 , 111 , 61 );
}

gövde {
   arka plan : lineer-gradient( 90deg , var(--color- 1 ) %0 , var(--color- 1 ) %25 , var(--color- 2 ) %25 , var(--color- 2 ) %50 , var(--color- 3 ) %50 , var(--color- 3 ) %75 , var(--color- 4 ) %75 , var(--color- 4 ) %100 );
} gövde {
   arka plan : #20262e ;
   dolgu : 16px ;
   yazı tipi ailesi : Helvetica;
}

gövde ::-webkit-kaydırma çubuğu {
  genişlik: 5px ;
}

gövde ::-webkit-kaydırma çubuğu-izi {
  arka plan: şeffaf;
}

gövde ::-webkit-kaydırma çubuğu-başparmak {
  konum: mutlak;
  arka plan : #374353ff ;
   kenarlık yarıçapı : 5px ;
}

.inputs-wrapper {
   ekran : esnek;
   esnek-yön : sütun;
  boşluk: 12px ;
}

.alan-grubu {
   görüntüleme : esnek;
   esnek-yön : sütun;
  boşluk: 6px ;
}

.label {
   yazı tipi boyutu : 12px ;
   satır yüksekliği : 14px ;
   renk : beyaz;
}

.input {
   genişlik : %100 ;
   dolgu : 4px ;

  & :focus {
     anahat : hiçbiri;
  }
}

.field {
   görüntüleme : flex;
   flex-direction : sütun;
  boşluk: 4px ;
}

.divider {
   genişlik : %100 ;
   yükseklik : 1px ;
   arka plan : gri;
}

.section {
   görüntüleme : flex;
   flex-yön : sütun;
  boşluk: 4px ;
}

.table-wrapper {
   taşma-x : otomatik;
}

.tablo-sarmalayıcı ::-webkit-kaydırma çubuğu {
  genişlik: 5px ;
}

.tablo-sarmalayıcı ::-webkit-kaydırma çubuğu-izi {
  arka plan: şeffaf;
}

.tablo-sarmalayıcı ::-webkit-kaydırma çubuğu-küçük resim {
  konum: mutlak;
  arka plan : #374353ff ;
   kenarlık yarıçapı : 5px ;
}

tablo {
   genişlik : %100 ;
   kenarlık-daraltma : daralt;
}

tablo  th {
   dolgu : 8px ;
   kenarlık : 1px düz gri;
   renk : beyaz;
   yazı tipi boyutu : 12px ;
   boşluk : nowrap;
   yazı tipi ağırlığı : 600 ;
}

tablo  td {
   dolgu : 8px ;
   kenarlık : 1px düz gri;
   renk : beyaz;
   yazı tipi boyutu : 12px ;
   metin hizalaması : orta;
}

tablo  başlığı  td {
   yazı tipi ağırlığı : 600 ;
}

.text {
   renk : beyaz;
   yazı tipi boyutu : 14px ;
   yazı tipi stili : italik;
}

.altyazı {
   renk : beyaz;
   yazı tipi boyutu : 14px ;
   yazı tipi ağırlığı : 600 ;
}

.math {
   dolgu : 4px ;
   renk : beyaz;
   yazı tipi boyutu : 12px ;
}
