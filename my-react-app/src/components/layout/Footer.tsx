export const Footer = () => {
  return (
    <footer className="bg-white border-t border-slate-200 pt-12 pb-8">
      <div className="container mx-auto px-4">
        <div className="grid grid-cols-1 md:grid-cols-3 gap-8 mb-8">
          <div>
            <h4 className="text-xl font-bold mb-4">BookHub</h4>
            <p className="text-slate-500 text-sm leading-relaxed">
              Ваша персональна цифрова бібліотека. Читайте, оцінюйте та діліться враженнями про улюблені книги.
            </p>
          </div>
          <div>
            <h4 className="font-semibold mb-4">Навігація</h4>
            <ul className="space-y-2 text-slate-600 text-sm">
              <li><a href="#" className="hover:text-blue-600">Всі книги</a></li>
              <li><a href="#" className="hover:text-blue-600">Новинки</a></li>
              <li><a href="#" className="hover:text-blue-600">Рекомендації</a></li>
            </ul>
          </div>
          <div>
            <h4 className="font-semibold mb-4">Підтримка</h4>
            <ul className="space-y-2 text-slate-600 text-sm">
              <li><a href="#" className="hover:text-blue-600">Контакти</a></li>
              <li><a href="#" className="hover:text-blue-600">FAQ</a></li>
              <li><a href="#" className="hover:text-blue-600">Політика приватності</a></li>
            </ul>
          </div>
        </div>
        <div className="border-t border-slate-100 pt-8 text-center text-slate-400 text-xs">
          © {new Date().getFullYear()} BookLib. Всі права захищено.
        </div>
      </div>
    </footer>
  );
};