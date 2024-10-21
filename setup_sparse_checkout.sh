#!/bin/bash

# Проверка, что скрипт запускается из корневой директории Git репозитория
if [ ! -d ".git" ]; then
    echo "Этот скрипт нужно запускать из корневой директории Git репозитория."
    exit 1
fi

# Сброс настроек sparse-checkout для главного репозитория
echo "Сброс настроек sparse-checkout для главного репозитория..."
git sparse-checkout disable  # Отключение sparse-checkout
git checkout .                # Восстановление всех файлов

# Инициализация сабмодулей
echo "Инициализация сабмодулей..."
git submodule update --init --recursive

# Настройка sparse-checkout для сабмодуля IdleRpg
echo "Инициализируй sparse-checkout для сабмодуля IdleRpg..."
cd Assets/ExternalGames/IdleRpg || exit
git sparse-checkout init --cone                      
git sparse-checkout set Assets/_IdleRpgGame                            
cd -                                                

# Обновление сабмодуля IdleRpg
git submodule update --init --recursive              

# Настройка sparse-checkout для сабмодуля Platformer
echo "Инициализируй sparse-checkout для сабмодуля Platformer..."
cd Assets/ExternalGames/Platformer || exit
git sparse-checkout init --cone                     
git sparse-checkout set Assets/_Platformer 
cd -                                                 

# Обновление сабмодуля Platformer
git submodule update --init --recursive               

echo "Сабмодули успешно настроены с sparse-checkout!"
