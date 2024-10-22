#!/bin/bash

# Проверка, что скрипт запускается из корневой директории Git репозитория
if [ ! -d ".git" ]; then
    echo "Этот скрипт нужно запускать из корневой директории Git репозитория."
    exit 1
fi

# Инициализация сабмодулей
echo "Инициализация сабмодулей..."
git submodule update --init --recursive

# Настройка sparse-checkout для сабмодуля IdleRpg и переключение на ветку main
echo "Инициализация sparse-checkout и переключение на ветку main для сабмодуля IdleRpg..."
cd Assets/ExternalGames/IdleRpg || exit
git checkout main || git checkout -b main  # Переключение на ветку main, если она существует, или создание
git pull origin main  # Подтянуть изменения из ветки main
git sparse-checkout init --cone                      
git sparse-checkout set Assets/_IdleRpgGame                            
cd -

# Настройка sparse-checkout для сабмодуля Platformer и переключение на ветку main
echo "Инициализация sparse-checkout и переключение на ветку main для сабмодуля Platformer..."
cd Assets/ExternalGames/Platformer || exit
git checkout main || git checkout -b main  # Переключение на ветку main, если она существует, или создание
git pull origin main  # Подтянуть изменения из ветки main
git sparse-checkout init --cone                     
git sparse-checkout set Assets/_Platformer 
cd -

# Обновление сабмодулей
echo "Обновление сабмодулей..."
git submodule update --remote --recursive       

echo "Сабмодули успешно настроены!"